﻿using MSWadConsole20.Repository.DataModel.Request;
using MSWadConsole20.Repository.DataModel.Response;
using MSWadConsole20.Repository.DataModel;
using MSWadConsole20.Repository.DataModel.Data;

namespace MSWadConsole20.Contract
{
    public interface IReferentRepository
    {
        ServiceResponse<StoredData<ReferenteData>> GetReferent(ReferentRequest request);
        ServiceResponse<StoredData<List<ReferenteData>>> GetReferents(ReferentRequest request);
        ServiceResponse<StoredData<List<TipiReferenti>>> GetTypeReferents(TipiReferentiRequest request);
    }
}
