using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces.Models
{
    public interface ITipoPagamento : IBaseModel
    {
        string Nome { get; set; }
        
        List<IVenda> Vendas { get; }
        
        List<ICompra> Compras { get; }
        
        /// <summary>
        /// Permissões necessarias para poder ler a propriedade.
        /// </summary>
        RoleType RolesCanRead { get; set; }
    }

    [Flags]
    [JsonConverter(typeof(StringEnumConverter))]
    public enum RoleType
    {
        Inherited = 1,
        Anonymous = 2,
        Viewer = 4,
        PlatformSuper = 8,
        PlatformAdministrator = 16,
        AdministratorGlobal = 32,
        ContributorGlobal = 64,
        ReaderGlobal = 128,
        System = 256,
        GuideAdmin = 512,
        GuideContributor = 1024,
        TemplateAdmin = 2048,
        TemplateContributor = 4096,
        TemplateViewer = 8192,
        LearningAdmin = 16384,
        LearningContributor = 32768,
        ReviewAdmin = 65536,
        ReviewContributor = 131072,
        UserAdmin = 262144,
        SchemaAdmin = 524288,
        SchemaContributor = 1048576,
        EntityAdmin = 2097152,
        EntityContributor = 4194304,
        LearningUserAdmin = 8388608,
        SocialMediaAdmin = 16777216,
        SocialMediaContributor = 33554432,
        UserImpersonate = 67108864,
        NotificationAdmin = 134217728
    }
}
