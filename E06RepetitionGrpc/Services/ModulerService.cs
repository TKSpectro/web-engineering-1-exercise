using E06RepetitionRest.Models;
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;

namespace E06RepetitionGrpc.Services
{
    public class ModulerService : E06RepetitionGrpc.Moduler.ModulerBase
    {
        private readonly ILogger<ModulerService> _logger;
        private readonly MyDbContext _context;
        
        public ModulerService(ILogger<ModulerService> logger, MyDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public override Task<Empty> AddModule(Module request, ServerCallContext context)
        {
            var module = new E06RepetitionRest.Models.Module()
                {Id = new Guid(), Name = request.Name, Cp = request.Cp, Sws = request.Sws};
            
            _context.Modules.Add(module);
            _context.SaveChanges();
            
            return base.AddModule(request, context);
        }
        
        public override Task<ModuleList> GetModules(Google.Protobuf.WellKnownTypes.Empty request, ServerCallContext context)
        {
            var moduleList = new ModuleList();
            var modules = _context.Modules.ToList();
            
            foreach (var module in modules)
            {
                var protoModule = new Module
                {
                    Id = module.Id.ToString(),
                    Name = module.Name,
                    Cp = module.Cp,
                    Sws = module.Sws
                };
                moduleList.Modules.Add(protoModule);
            }
            
            return Task.FromResult(moduleList);
        }

        public override Task<Empty> DeleteModule(Module request, ServerCallContext context)
        {
            _context.Modules.Remove(new E06RepetitionRest.Models.Module 
            {
                Id = new Guid(request.Id), Name = request.Name, Cp = request.Cp, Sws = request.Sws
            });
            return base.DeleteModule(request, context);
        }

        public override Task<Empty> UpdateModule(Module request, ServerCallContext context)
        {
            _context.Modules.Update(new E06RepetitionRest.Models.Module
            {
                Id = new Guid(request.Id), Name = request.Name, Cp = request.Cp, Sws = request.Sws
            });
            
            return base.UpdateModule(request, context);
        }
    }
}
