using Microsoft.EntityFrameworkCore;
using System.Text.Json;
using DbContextProfi;
using Entities;
using ConsoleAppCreateDbProfi.TestData.CreatorEntities;

namespace ConsoleAppCreateDbProfi.CreatorSystem
{
    internal class CreatorDbProfi
    {
        private readonly DbContextProfiСonnector _context;

        private readonly string _FilesDdirectory;

        public CreatorDbProfi(DbContextProfiСonnector context)
        {
            _context = context;
            _FilesDdirectory = @"..\..\..\TestData\";
        }

        public void CreateDbProfi()
        {
            _context.Database.Migrate();

            var roles = FillUserRolesTable();
            FillUsersTable(roles);

            FillMenuSetsTable("menuSets.json");

            FillProjectsTable("projects.json");
            FillServicesTable("services.json");
            FillBlogsTable("blogs.json");
            FillContactsTable("contacts.json");

            FillSlogansTable("slogans.json");

            // Берётся по одному элементу для одного пресета.
            var text = FillTextsTable("texts.json", 3);
            var image = FillImagesTable("images.json", 1);
            var phrase = FillPhraseTable("phrases.json", 2);
            var action = FillActionsTable("actions.json", 0);
            var button = FillButtonsTable("buttons.json", 1);

            FillPagePresetTable("Preset number 1", action, button, image, phrase, text);

            _context.SaveChanges();

            Console.WriteLine("Всё, база данных заполнена тестовыми данными. Но это не точно...");
        }

        private UserRoleEntity[] FillUserRolesTable()
        {
            //Ограниченный уровень доступа - заявки
            var juniorRole = new UserRoleEntity()
            {
                Name = "Junior",
            };

            //Ограниченный уровень доступа - тоже, что и у младшего и ещё контент гостевого сайта: проекты, услуги, блоги, контакты
            var seniorRole = new UserRoleEntity()
            {
                Name = "Senior",
            };

            //Полный уровень доступа - всё что у работников и ещё оформление гостевого сайта: заголовок(меню, слоган), главная сртаница
            var adminRole = new UserRoleEntity()
            {
                Name = "Admin",
            };

            _context.Roles.Add(juniorRole);
            _context.Roles.Add(seniorRole);
            _context.Roles.Add(adminRole);

            var roles = new UserRoleEntity[] { juniorRole, seniorRole, adminRole};
            return roles;
        }

        private void FillUsersTable(UserRoleEntity[] roles)
        {
            //pass: 111111
            var junior = new UserEntity()
            {
                Login = "junior",
                PasswordSalt = "38fde5569cbf4f3bb3a30b2ad30cb9c8",
                PasswordHash = "CKWIZ6DS1AL4UBolqMtMhLDI7HujbGqzGL/covwMNUM=",
                Role = roles[0],
            };

            //pass: 222222
            var senior = new UserEntity()
            {
                Login = "senior",
                PasswordSalt = "cd7f988c2ee8401f80820d6aa017f50b",
                PasswordHash = "9+cs5wj2/DYRa6f0+oiE924BSgzvcDO0KDIYzbTbh3E=",
                Role = roles[1],
            };

            //pass: 333333
            var admin = new UserEntity()
            {
                Login = "admin",
                PasswordSalt = "c779e07ada924bef9230113e03f5cdc5",
                PasswordHash = "WJKe5gond5QYbFiX06/6NOLaTyaiAGobA9FSk63aqrs=",
                Role = roles[2]
            };

            _context.Users.Add(junior);
            _context.Users.Add(senior);
            _context.Users.Add(admin);
        }

        private TCreatorEntity[] GetTestEntities<TCreatorEntity>(string nameJsonFile) where TCreatorEntity : class
        {
            var pathJsonFile = Path.Combine(_FilesDdirectory, nameJsonFile);

            if (!File.Exists(pathJsonFile))
            {
                return new TCreatorEntity[0];
            }

            var entitiesJson = File.ReadAllText(pathJsonFile);
            var testEntities = JsonSerializer.Deserialize<TCreatorEntity[]>(entitiesJson);

            return testEntities ?? new TCreatorEntity[0];
        }

        private void FillMenuSetsTable(string menuSetsNameJson)
        {
            var sets = GetTestEntities<MenuCreatorEntity>(menuSetsNameJson);

            foreach (var set in sets)
            {
                var entity = new HeaderMenuEntity
                {
                    Main = set.Main,
                    Services = set.Services,
                    Projects = set.Projects,
                    Blogs = set.Blogs,
                    Contacts = set.Contacts,
                    IsPublishedOnMainPage = set.IsPosted
                };

                _context.HeaderMenus.Add(entity);
            }
        }

        private void FillProjectsTable(string projectsNameJsonFile)
        {
            var projects = GetTestEntities<ProjectCreatorEntity>(projectsNameJsonFile);

            foreach (var project in projects)
            {
                _context.Projects.Add(new ProjectEntity
                {
                    Title = project.Title,
                    ProjectDescription = project.Description,
                    LinkToCustomerSite = project.Link,
                    CustomerCompanyLogoAsArray64 = Convert.FromBase64String(project.Image),
                    IsPublished = project.IsUsed
                });
            }
        }

        private void FillServicesTable(string servicesNameJsonFile)
        {
            var services = GetTestEntities<ServiceCreatorEntity>(servicesNameJsonFile);

            foreach (var service in services)
            {
                _context.Services.Add(new ServiceEntity
                {
                    Title = service.Title,
                    ServiceDescription = service.Description,
                    IsPublished = service.IsUsed
                });
            }
        }

        private void FillBlogsTable(string blogsNameJsonFile)
        {
            var blogs = GetTestEntities<BlogCreatorEntity>(blogsNameJsonFile);

            foreach (var blog in blogs)
            {
                _context.Blogs.Add(new BlogEntity
                {
                    Title = blog.Title,
                    ShortBlogDescription = blog.ShortDescription,
                    LongBlogDescription = blog.LongDescription,
                    BlogImageAsArray64 = Convert.FromBase64String(blog.BlogImage),
                    PublicationDate = blog.Publication,
                    IsPublished = blog.IsUsed,
                });
            }
        }

        private void FillContactsTable(string contactsNameJsonFile)
        {
            var contacts = GetTestEntities<ContactCreatorEntity>(contactsNameJsonFile);

            foreach (var contact in contacts)
            {
                _context.Contacts.Add(new ContactEntity
                {
                    Address = contact.Address,
                    MapAsArray64 = Convert.FromBase64String(contact.Map),
                    Phone = contact.Phone,
                    Fax = contact.Fax,
                    Postcode = contact.Postcode,
                    IsPublishedOnMainPage = contact.IsPosted,
                });
            }
        }

        private MainPageTextEntity? FillTextsTable(string textsNameJsonFile, int forPresetIndex)
        {
            var texts = GetTestEntities<TextCreatorEntity>(textsNameJsonFile);

            MainPageTextEntity? forPreset = null;
            for (int i = 0; i < texts.Length; i++)
            {
                var entity = new MainPageTextEntity
                {
                    Text = texts[i].Text
                };

                _context.MainPageTexts.Add(entity);

                if (i == forPresetIndex)
                {
                    forPreset = entity;
                }
            }

            return forPreset;
        }

        private MainPageImageEntity? FillImagesTable(string imagesNameJsonFile, int forPresetIndex)
        {
            var images = GetTestEntities<ImageCreatorEntity>(imagesNameJsonFile);

            MainPageImageEntity? forPreset = null;
            for (int i = 0; i < images.Length; i++)
            {
                var entity = new MainPageImageEntity
                {
                    ImageAsArray64 = Convert.FromBase64String(images[i].Image),
                };

                _context.MainPageImages.Add(entity);

                if (i == forPresetIndex)
                {
                    forPreset = entity;
                }
            }

            return forPreset;
        }

        private MainPagePhraseEntity? FillPhraseTable(string phrasesNameJsonFile, int forPresetIndex)
        {
            var phrases = GetTestEntities<PhraseCreatorEntity>(phrasesNameJsonFile);

            MainPagePhraseEntity? forPreset = null;
            for (int i = 0; i < phrases.Length; i++)
            {
                var entity = new MainPagePhraseEntity
                {
                    Phrase = phrases[i].Phrase,
                };

                _context.MainPagePhrases.Add(entity);

                if (i == forPresetIndex)
                {
                    forPreset = entity;
                }
            }

            return forPreset;
        }

        private MainPageActionEntity? FillActionsTable(string actionsNameJsonFile, int forPresetIndex)
        {
            var actions = GetTestEntities<ActionCreatorEntity>(actionsNameJsonFile);

            MainPageActionEntity? forPreset = null;
            for (int i = 0; i < actions.Length; i++)
            {
                var entity = new MainPageActionEntity
                {
                    Action = actions[i].Action,
                };

                _context.MainPageActions.Add(entity);

                if (i == forPresetIndex)
                {
                    forPreset = entity;
                }
            }

            return forPreset;
        }

        private MainPageButtonEntity? FillButtonsTable(string buttonsNameJsonFile, int forPresetIndex)
        {
            var buttons = GetTestEntities<ButtonCreatorEntity>(buttonsNameJsonFile);

            MainPageButtonEntity? forPreset = null;
            for (int i = 0; i < buttons.Length; i++)
            {
                var entity = new MainPageButtonEntity
                {
                    Button = buttons[i].Button,
                };

                _context.MainPageButtons.Add(entity);

                if (i == forPresetIndex)
                {
                    forPreset = entity;
                }
            }

            return forPreset;
        }

        private void FillSlogansTable(string slogansNameJsonFile)
        {
            var slogans = GetTestEntities<SloganCreatorEntity>(slogansNameJsonFile);

            foreach (var slogan in slogans)
            {
                var entity = new HeaderSloganEntity
                {
                    Slogan = slogan.Slogan,
                    IsUsed = slogan.IsUsed
                };

                _context.HeaderSlogans.Add(entity);
            }
        }

        private void FillPagePresetTable(
            string presetName,
            MainPageActionEntity? action,
            MainPageButtonEntity? button,
            MainPageImageEntity? image,
            MainPagePhraseEntity? phrase,
            MainPageTextEntity? text)
        {
            var preset = new MainPagePresetEntity
            {
                PresetName = presetName,
                Text = text,
                Image = image,
                Phrase = phrase,
                Action = action,
                Button = button,
                IsPublishedOnMainPage = true
            };

            _context.MainPagePresets.Add(preset);
        }
    }
}
