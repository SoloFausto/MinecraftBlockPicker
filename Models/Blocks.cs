namespace BlazorApp1.Models {
    public class Blocks {
        public string? file_name { get; set; }
        public string? image_base64 { get; set; }
        public Blocks(string? file_name, string image_base64) { 
            this.file_name = file_name;
            this.image_base64 = image_base64;
        }
    }

}   

