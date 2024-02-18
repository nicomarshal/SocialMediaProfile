namespace SocialMediaProfile.Core.Models.DTOs
{
    public class UserDTO
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Alias { get; set; }
        public int RoleId { get; set; }
        public RoleDTO Role { get; set; } //ManyToOne
        public PersonDTO Person { get; set; } //OneToOne    
        public List<ExperienceDTO> Experiencies { get; set; } //OneToMany
        public List<EducationDTO> Educations { get; set; } //OneToMany
        public List<ProjectDTO> Projects { get; set; } //OneToMany
        public List<SkillDTO> Skills { get; set; } //OneToMany
    }
}