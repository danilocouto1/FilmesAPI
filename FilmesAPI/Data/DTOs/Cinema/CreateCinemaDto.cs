namespace FilmesAPI.Data.Dtos
{
    public class CreateCinemaDto
    {
        public string Nome { get; set; }
        public int EnderecoFK { get; set; }
        public int GerenteFK { get; set; }
    }
}
