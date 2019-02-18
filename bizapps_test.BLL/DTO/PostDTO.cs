using System;


namespace bizapps_test.BLL.DTO
{
    public class PostDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public DateTime CreationDate { get; set; }
        public string PostImage { get; set; }
    }
}
