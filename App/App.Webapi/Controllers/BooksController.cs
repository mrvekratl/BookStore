using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace App.Webapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        public static List<Book> _books = new List<Book>
        {
            new Book { Id = 1, Title = "Simyacı", Author =  "Paulo Coelho", PublishedYear = 1988 },
            new Book { Id = 2, Title = "Fahrenheit 451", Author ="Ray Bradbury", PublishedYear = 1953 },
            new Book { Id = 3, Title = "Momo", Author ="Michael Ende", PublishedYear = 1973 },
            new Book { Id = 4, Title = "Cesur Yeni Dünya", Author ="Aldous Huxley", PublishedYear = 1932 },
            new Book { Id = 5, Title = "Çavdar Tarlasında Çocuklar", Author ="J. D. Salinger", PublishedYear = 1951 },
            new Book { Id = 6, Title = "Gazi Mustafa Kemal Atatürk", Author =  "Prof. Dr. İlber Ortaylı", PublishedYear = 2018 },
            new Book { Id = 7, Title = "Olasılıksız", Author ="Adam Fawer", PublishedYear = 2005 },
            new Book { Id = 8, Title = "Aklından Bir Sayı Tut", Author ="John Verdon", PublishedYear = 2010 },
            new Book { Id = 9, Title = "Toprak Ana", Author ="Cengiz Aytmatov", PublishedYear = 1963 },
            new Book { Id = 10, Title = "Nietzsche Ağladığında", Author ="Irvin D. Yalom", PublishedYear = 1992 },
            new Book { Id = 11, Title = "Gece Yarısı Kütüphanesi", Author = "Matt Haig", PublishedYear = 2020 },
            new Book { Id = 12, Title = "Masumiyet Müzesi", Author ="Orhan Pamuk", PublishedYear = 2008 },
            new Book { Id = 13, Title = "Cemile", Author ="Cengiz Aytmatov", PublishedYear = 1958 },
            new Book { Id = 14, Title = "The Little Prince", Author =" Antoine de Saint-Exupéry", PublishedYear = 1943 },
            new Book { Id = 15, Title = "Bir İdam Mahkumunun Son Günü", Author ="Victor Hugo", PublishedYear = 1829 },
            new Book { Id = 16, Title = "Kayıp Tanrılar Ülkesi", Author =  "Ahmet Ümit", PublishedYear = 2021 },
            new Book { Id = 17, Title = "Ben Kirke", Author ="Madeline Miller", PublishedYear = 2019 },
            new Book { Id = 18, Title = "Yaşamak", Author ="Yu Hua", PublishedYear = 1992 },
            new Book { Id = 19, Title = "Sineklerin Tanrısı", Author ="William Golding", PublishedYear = 1954 },
            new Book { Id = 20, Title = "Şeker Portakalı", Author ="José Mauro de Vasconcelos", PublishedYear = 1968 }

        };

        [HttpGet]        
        public IEnumerable<Book> GetList()
        {            
            return _books;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(Book))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [Consumes(typeof(Book), "application/json")]
        public IActionResult AddBook([FromBody] Book book)
        {
            _books.Add(book);
            if(book == null)
            {
                return BadRequest("Kitap eklenemedi");
            }
            return Created();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [Consumes(typeof(Book), "application/json")]
        public IActionResult DeleteBook([FromBody] int id)
        {
            var item = _books.Find(x => x.Id == id);
            if(item == null)
            {
                return BadRequest("Aradığınız kitap bulunamamaktadır.");
            }
            _books.Remove(item);
            return Ok();
        }




    }
}
