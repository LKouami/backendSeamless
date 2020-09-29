using Microsoft.Extensions.Logging;
using Seamless.Data.IRepositories;
using Seamless.Domain.Dxos;
using Seamless.Model.Dtos;
using Seamless.Model.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Seamless.Data.Repositories
{
    public class PermissionRepository : Repository<SPermission, PermissionDto, IPermissionDxos>, IPermissionRepository
    {
        public PermissionRepository(SeamlessContext dbContext,
           ILogger<PermissionRepository> logger,
           IPermissionDxos permissionDxos) : base(dbContext, logger, permissionDxos)
        {
            //Code removed here
        }
    }
}
