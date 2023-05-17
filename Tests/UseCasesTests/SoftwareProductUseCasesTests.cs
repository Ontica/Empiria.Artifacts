/* Empiria OnePoint Artifacts ********************************************************************************
*                                                                                                            *
*  Module   : Software Configuration Management          Component : Test cases                              *
*  Assembly : Empiria.OnePoint.Artifacts.Tests.dll       Pattern   : Use cases tests                         *
*  Type     : SoftwareFeaturesUseCases                   License   : Please read LICENSE.txt file            *
*                                                                                                            *
*  Summary  : Provides testing constants.                                                                    *
*                                                                                                            *
************************* Copyright(c) La Vía Óntica SC, Ontica LLC and contributors. All rights reserved. **/
using Xunit;

using Empiria.Artifacts.UseCases;

namespace Empiria.Tests.Artifacts {

  /// <summary>Test cases for system features.</summary>
  public class SoftwareProductUseCasesTests {

    #region Facts

    [Fact]
    public void Should_Get_Software_Products() {

      using (var usecase = SoftwareProductUseCases.UseCaseInteractor()) {
        FixedList<NamedEntityDto> products = usecase.GetSoftwareProducts();

        Assert.NotEmpty(products);
      }
    }

    #endregion Facts

  }  // class SoftwareFeaturesUseCases

}  // namespace Empiria.Tests.Artifacts
