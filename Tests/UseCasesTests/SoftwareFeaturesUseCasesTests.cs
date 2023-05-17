/* Empiria OnePoint Artifacts ********************************************************************************
*                                                                                                            *
*  Module   : Software Configuration Management          Component : Test cases                              *
*  Assembly : Empiria.OnePoint.Artifacts.Tests.dll       Pattern   : Use cases tests                         *
*  Type     : SoftwareFeaturesUseCasesTests              License   : Please read LICENSE.txt file            *
*                                                                                                            *
*  Summary  : Provides testing constants.                                                                    *
*                                                                                                            *
************************* Copyright(c) La Vía Óntica SC, Ontica LLC and contributors. All rights reserved. **/
using Xunit;

using Empiria.Artifacts.UseCases;
using Empiria.Artifacts.Adapters;

namespace Empiria.Tests.Artifacts {

  /// <summary>Test cases for system features.</summary>
  public class SoftwareFeaturesUseCasesTests {

    #region Facts

    [Fact]
    public void Should_Read_Software_Features() {

      using (var usecase = SoftwareFeaturesUseCases.UseCaseInteractor()) {
        FixedList<FeatureDto> features = usecase.GetFeatures(TestingConstants.TESTING_SYSTEM_GUID);

        Assert.NotEmpty(features);

      }
    }

    [Fact]
    public void Should_Append_A_Grouping_Feature() {

      const string TEST_GROUP_NAME = "Test grouping feature";

      using (var usecases = SoftwareFeaturesUseCases.UseCaseInteractor()) {
        FixedList<FeatureDto> features =
                        usecases.GetFeatures(TestingConstants.TESTING_SYSTEM_GUID);
        var command = new InsertFeatureCommand {
          Name = TEST_GROUP_NAME,
          IsGroupingFeature = true,
          SoftwareProductUID = TestingConstants.TESTING_SYSTEM_GUID
        };

        int sut = features.Count;

        features = usecases.InsertFeature(command);

        Assert.Equal(sut + 1, features.Count);

        Assert.Equal(TEST_GROUP_NAME, features[sut].Name);
        Assert.True(features[sut].IsGroupingFeature);
      }
    }

    [Fact]
    public void Should_Delete_A_Feature() {
      using (var usecases = SoftwareFeaturesUseCases.UseCaseInteractor()) {
        FixedList<FeatureDto> features =
                        usecases.GetFeatures(TestingConstants.TESTING_SYSTEM_GUID);

        FeatureDto toDelete = features.FindLast(x => !x.IsGroupingFeature);

        int sut = features.Count;

        usecases.Delete(TestingConstants.TESTING_SYSTEM_GUID, toDelete.UID);

        features = usecases.GetFeatures(TestingConstants.TESTING_SYSTEM_GUID);

        Assert.Equal(sut - 1, features.Count);
      }
    }

    [Fact]
    public void Should_Insert_A_Grouping_Feature() {

      const string TEST_GROUP_NAME = "Test grouping feature";
      const int INDEX = 25;

      using (var usecases = SoftwareFeaturesUseCases.UseCaseInteractor()) {
        FixedList<FeatureDto> features =
                        usecases.GetFeatures(TestingConstants.TESTING_SYSTEM_GUID);
        var command = new InsertFeatureCommand {
          Name = TEST_GROUP_NAME,
          IsGroupingFeature = true,
          SoftwareProductUID = TestingConstants.TESTING_SYSTEM_GUID,
          Index = INDEX,
        };

        int sut = features.Count;

        features = usecases.InsertFeature(command);

        Assert.Equal(sut + 1, features.Count);

        Assert.Equal(TEST_GROUP_NAME, features[INDEX].Name);
        Assert.True(features[INDEX].IsGroupingFeature);
      }
    }

    #endregion Facts

  }  // class SoftwareFeaturesUseCases

}  // namespace Empiria.Tests.Artifacts
