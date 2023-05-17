/* Empiria OnePoint Artifacts ********************************************************************************
*                                                                                                            *
*  Module   : Software Configuration Management          Component : Test Helpers                            *
*  Assembly : Empiria.OnePoint.Artifacts.Tests.dll       Pattern   : Testing constants                       *
*  Type     : TestingConstants                           License   : Please read LICENSE.txt file            *
*                                                                                                            *
*  Summary  : Provides testing constants.                                                                    *
*                                                                                                            *
************************* Copyright(c) La Vía Óntica SC, Ontica LLC and contributors. All rights reserved. **/

using System;

namespace Empiria.Tests.Artifacts {

  /// <summary>Provides testing constants.</summary>
  static public class TestingConstants {

    static internal string TESTING_SYSTEM_GUID => ConfigurationData.GetString("TESTING_SYSTEM_GUID");

  }  // class TestingConstants

}  // namespace Empiria.Compliance.Tests
