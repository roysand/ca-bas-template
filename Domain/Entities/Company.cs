using System;
using System.Text;
using System.Collections.Generic;


namespace Domain.Entities {
    
    public record Company {
        public string OrganizationNo { get; init; }
        public string Profile { get; init; }
    }
}
