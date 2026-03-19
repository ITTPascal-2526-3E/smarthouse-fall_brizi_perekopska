using BlaisePascal.SmartHouse.Domain.Security;
using BlaisePascal.SmartHouse.Domain.Security.Repositories;
using BlaisePascal.SmartHouse.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.SmartHouse.Infrastructure.Repositories.Devices.Security.CCTVs
{
    public class InMemoryCCTVRepository : ICCTVRepository
    {
        private readonly List<CCTV> _cctvs;

        public InMemoryCCTVRepository()
        {
            _cctvs = new List<CCTV>
            {
                new CCTV(Name.From("Name")),
                new CCTV(Name.From("Name2"))
            };
        }

        public List<CCTV> GetAll()
        {
            return _cctvs;
        }

        public CCTV GetById(Guid id)
        {
            return _cctvs.FirstOrDefault(cctv => cctv.Id == id);
        }

        public void Add( CCTV cctv)
        {
            if (cctv == null)
                throw new ArgumentNullException(nameof(cctv));
            _cctvs.Add(cctv);
        }

        public void Remove(Guid id)
        {
            var cctv = GetById(id);
            if (cctv != null)
                _cctvs.Remove(cctv);
        }

        public void Update(CCTV cctv)
        {
            // Not to do
        }
    }
}
