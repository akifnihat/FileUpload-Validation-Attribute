﻿namespace LayoutService_AdminPanel.Models
{
    public class BookTag
    {
        public int TagId { get; set; }
        public Tag Tag { get; set; }
        public int BookId { get; set; }
        public Book Book { get; set; }
    }
}
