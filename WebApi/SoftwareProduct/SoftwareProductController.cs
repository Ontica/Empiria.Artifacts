/* Empiria OnePoint Artifacts ********************************************************************************
*                                                                                                            *
*  Module   : Software Configuration Management            Component : Web Api                               *
*  Assembly : Empiria.Artifacts.WebApi.dll                 Pattern   : Query controller                      *
*  Type     : SoftwareProductController                    License   : Please read LICENSE.txt file          *
*                                                                                                            *
*  Summary  : Web api with search and edition services for softweare produxts.                               *
*                                                                                                            *
************************* Copyright(c) La Vía Óntica SC, Ontica LLC and contributors. All rights reserved. **/
using System;
using System.Web.Http;

using Empiria.WebApi;

using Empiria.Artifacts.UseCases;

namespace Empiria.Artifacts.WebApi {

  /// <summary>Query web api with search services for the internal use of Land Recording Offices.</summary>
  public class SoftwareProductController : WebApiController {

    #region Web Apis

    [HttpGet]
    [Route("v1/artifacts/software-products")]
    public CollectionModel GetSoftwareProducts() {

      using (var usecases = SoftwareProductUseCases.UseCaseInteractor()) {

        FixedList<NamedEntityDto> list = usecases.GetSoftwareProducts();

        return new CollectionModel(this.Request, list);
      }
    }

    #endregion Web Apis

  }  // class SoftwareProductController

}  // namespace Empiria.Artifacts.WebApi
