using SocialMediaProfile.Core.Models.DTOs;
using SocialMediaProfile.DataAccess.Entities;

namespace SocialMediaProfile.Core.Mappers
{
    public class PersonMapper
    {
        public static PersonDTO PersonToPersonDTO(Person person)
        {
            PersonDTO personDTO = new PersonDTO()
            {
                Id = person.Id,
                ProfileImg = person.ProfileImg,
                Name = person.Name,
                Surname = person.Surname,
                Profession = person.Profession,
                AboutMe = person.AboutMe,
                UserId = person.UserId
            };
            return personDTO;
        }

        public static Person PersonDTOToPerson(PersonDTO personDTO)
        {
            Person person = new Person()
            {
                Id = personDTO.Id,
                ProfileImg = personDTO.ProfileImg,
                Name = personDTO.Name,
                Surname = personDTO.Surname,
                Profession = personDTO.Profession,
                AboutMe = personDTO.AboutMe,
                UserId = personDTO.UserId
            };
            return person;
        }

        public static Person PersonDTOToPerson(PersonDTO personDTO, Person person)
        {
            person.Id = personDTO.Id;
            person.ProfileImg = personDTO.ProfileImg;
            person.Name = personDTO.Name;
            person.Surname = personDTO.Surname;
            person.Profession = personDTO.Profession;
            person.AboutMe = personDTO.AboutMe;
            person.UserId = personDTO.UserId;

            return person;
        }
    }
}
