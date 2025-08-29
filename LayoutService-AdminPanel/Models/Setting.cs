using System.ComponentModel.DataAnnotations;

namespace LayoutService_AdminPanel.Models
{
    public class Setting
    {
        [Key]
        public string Key { get; set; }
        public string Value { get; set; }
    }
}
