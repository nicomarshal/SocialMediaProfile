namespace SocialMediaProfile.Core.Entities
{
    public class User : EntityBase
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Alias { get; set; }

        public int RoleId { get; set; }
        public Role Role { get; set; } //ManyToOne

        public Person Person { get; set; } //OneToOne    

        public List<Experience> Experiencies { get; set; } //OneToMany
        public List<Education> Educations { get; set; } //OneToMany
        public List<Project> Projects { get; set; } //OneToMany
        public List<Skill> Skills { get; set; } //OneToMany
    }
}
