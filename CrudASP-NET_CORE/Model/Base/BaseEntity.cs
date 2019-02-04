using System.Runtime.Serialization;

namespace CrudASP_NET_CORE.Model.Base
{
    /**
     * Contrato entre atributos e estrutura da tabela
     * 
     */
    [DataContract]
    public class BaseEntity
    {
        public long Id { get; set; }
    }
}
