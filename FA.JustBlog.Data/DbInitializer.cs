using FA.JustBlog.Models.Common;
using FA.JustBlog.Models.Security;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace FA.JustBlog.Data
{
    public class DbInitializer : DropCreateDatabaseIfModelChanges<JustBlogDbContext>
    {
        protected override void Seed(JustBlogDbContext context)
        {
            InitializeIdentity(context);
            var categories = new Category[]
            {
                new Category
                {
                    Id = Guid.NewGuid(),
                    Name = "Travel",
                    UrlSlug =   "travel",
                    Description ="Travel Blog",
                    IsDeleted = false
                },
                new Category
                {
                    Id = Guid.NewGuid(),
                    Name = "Recipe",
                    UrlSlug =   "recipe",
                    Description ="Recipe Blog",
                    IsDeleted = false
                },
                new Category
                {
                    Id = Guid.NewGuid(),
                    Name = "Tips",
                    UrlSlug =   "tips",
                    Description ="Tips Blog",
                    IsDeleted = false
                },
                new Category
                {
                    Id = Guid.NewGuid(),
                    Name = "Life Style",
                    UrlSlug =   "life-style",
                    Description ="Life Style Blog",
                    IsDeleted = false
                }
            };

            var tag1 = new Tag
            {
                Id = Guid.NewGuid(),
                Name = "travel",
                UrlSlug = "travel",
                Description = "Travel Tag",
                IsDeleted = false
            };

            var tag2 = new Tag
            {
                Id = Guid.NewGuid(),
                Name = "food",
                UrlSlug = "food",
                Description = "food Tag",
                IsDeleted = false
            };

            var tag3 = new Tag
            {
                Id = Guid.NewGuid(),
                Name = "recipe",
                UrlSlug = "recipe",
                Description = "recipe Tag",
                IsDeleted = false
            };

            var tag4 = new Tag
            {
                Id = Guid.NewGuid(),
                Name = "tips",
                UrlSlug = "tips",
                Description = "tips Tag",
                IsDeleted = false
            };

            var tag5 = new Tag
            {
                Id = Guid.NewGuid(),
                Name = "study",
                UrlSlug = "study",
                Description = "study Tag",
                IsDeleted = false
            };

            var tag6 = new Tag
            {
                Id = Guid.NewGuid(),
                Name = "life style",
                UrlSlug = "life-style",
                Description = "life style Tag",
                IsDeleted = false
            };

            var tag7 = new Tag
            {
                Id = Guid.NewGuid(),
                Name = "setup",
                UrlSlug = "setup",
                Description = "setup Tag",
                IsDeleted = false
            };

            var posts = new List<Post>
            {
                new Post
                {
                    Id = Guid.NewGuid(),
                    Title = "Announcing TypeScript 4.4 RC",
                    UrlSlug = "announcing-typescript-44-rc",
                    ShortDescription = "This is a step by step tutorial on how ",
                    ImageUrl = "blog-1.jpg",
                    PostContent = "In JavaScript, we often have to probe a variable " +
                    "in different ways to see if it has a more specific type that we " +
                    "can use. TypeScript understands these checks and calls them type " +
                    "guards. Instead of having to convince TypeScript of a variable’s " +
                    "type whenever we use it, the type-checker leverages something called " +
                    "control flow analysis to deduce the type within every language " +
                    "construct.In previous versions of TypeScript, this would be an " +
                    "error – even though argIsString was assigned the value of a type " +
                    "guard, TypeScript simply lost that information. That’s unfortunate " +
                    "since we might want to re-use the same check in several places. " +
                    "To get around that, users often have to repeat themselves or " +
                    "use type assertions (casts).In TypeScript 4.4, that is no longer " +
                    "the case. The above example works with no errors! When TypeScript " +
                    "sees that we are testing a constant value, it will do a little bit " +
                    "of extra work to see if it contains a type guard. If that type guard " +
                    "operates on a const, a readonly property, or an un-modified parameter, " +
                    "then TypeScript is able to narrow that value appropriately.Different " +
                    "sorts of type guard conditions are preserved – not just typeof checks." +
                    "For example, checks on discriminated unions work like a charm.",
                    PublishedDate = DateTime.Now,
                    IsDeleted = false,
                    Published = true,
                    Category = categories.Single(x => x.Name == categories[0].Name),
                    Tags = new List<Tag>{tag1, tag2,tag3},
                    ImageSlider = "post-s-1.jpg",
                    ViewCount = 30,
                    RateCount = 16,
                    TotalRate = 68
                },
                new Post
                {
                    Id = Guid.NewGuid(),
                    Title = "Jetpack Window Manager alpha10 update",
                    UrlSlug = "jetpack-window-manager-alpha10-update",
                    ShortDescription = "This is a step by step tutorial on how ",
                    ImageUrl = "blog-2.jpg",
                    PostContent = "In JavaScript, we often have to probe a variable " +
                    "in different ways to see if it has a more specific type that we " +
                    "can use. TypeScript understands these checks and calls them type " +
                    "guards. Instead of having to convince TypeScript of a variable’s " +
                    "type whenever we use it, the type-checker leverages something called " +
                    "control flow analysis to deduce the type within every language " +
                    "construct.In previous versions of TypeScript, this would be an " +
                    "error – even though argIsString was assigned the value of a type " +
                    "guard, TypeScript simply lost that information. That’s unfortunate " +
                    "since we might want to re-use the same check in several places. " +
                    "To get around that, users often have to repeat themselves or " +
                    "use type assertions (casts).In TypeScript 4.4, that is no longer " +
                    "the case. The above example works with no errors! When TypeScript " +
                    "sees that we are testing a constant value, it will do a little bit " +
                    "of extra work to see if it contains a type guard. If that type guard " +
                    "operates on a const, a readonly property, or an un-modified parameter, " +
                    "then TypeScript is able to narrow that value appropriately.Different " +
                    "sorts of type guard conditions are preserved – not just typeof checks." +
                    "For example, checks on discriminated unions work like a charm.",
                    PublishedDate = DateTime.Now,
                    IsDeleted = false,
                    Published = true,
                    Category = categories.Single(x => x.Name == categories[3].Name),
                    Tags = new List<Tag>{tag1, tag4,tag3},
                    ImageSlider = "post-s-4.jpg",
                    ViewCount = 42,
                    RateCount = 61,
                    TotalRate = 88
                },
                new Post
                {
                    Id = Guid.NewGuid(),
                    Title = "The New JavaScript/TypeScript Experience in Visual Studio 2022 Preview 3",
                    UrlSlug = "the-new-javascript-typescript-experience-in-visual-studio-2022-preview-3",
                    ShortDescription = "This is a step by step tutorial on how ",
                    ImageUrl = "blog-3.jpg",
                    PostContent = "In JavaScript, we often have to probe a variable " +
                    "in different ways to see if it has a more specific type that we " +
                    "can use. TypeScript understands these checks and calls them type " +
                    "guards. Instead of having to convince TypeScript of a variable’s " +
                    "type whenever we use it, the type-checker leverages something called " +
                    "control flow analysis to deduce the type within every language " +
                    "construct.In previous versions of TypeScript, this would be an " +
                    "error – even though argIsString was assigned the value of a type " +
                    "guard, TypeScript simply lost that information. That’s unfortunate " +
                    "since we might want to re-use the same check in several places. " +
                    "To get around that, users often have to repeat themselves or " +
                    "use type assertions (casts).In TypeScript 4.4, that is no longer " +
                    "the case. The above example works with no errors! When TypeScript " +
                    "sees that we are testing a constant value, it will do a little bit " +
                    "of extra work to see if it contains a type guard. If that type guard " +
                    "operates on a const, a readonly property, or an un-modified parameter, " +
                    "then TypeScript is able to narrow that value appropriately.Different " +
                    "sorts of type guard conditions are preserved – not just typeof checks." +
                    "For example, checks on discriminated unions work like a charm.",
                    PublishedDate = DateTime.Now,
                    IsDeleted = false,
                    Published = true,
                    Category = categories.Single(x => x.Name == categories[1].Name),
                    Tags = new List<Tag>{tag5, tag2,tag3},
                    ImageSlider = "post-s-3.jpg",
                    ViewCount = 88,
                    RateCount = 66,
                    TotalRate = 688
                },
                new Post
                {
                    Id = Guid.NewGuid(),
                    Title = "How to make the most of this create a website tutorial",
                    UrlSlug = "how-to-make-the-most-of-this-create-a-website-tutorial",
                    ShortDescription = "This is a step by step tutorial on how ",
                    ImageUrl = "blog-4.jpg",
                    PostContent = "In JavaScript, we often have to probe a variable " +
                    "in different ways to see if it has a more specific type that we " +
                    "can use. TypeScript understands these checks and calls them type " +
                    "guards. Instead of having to convince TypeScript of a variable’s " +
                    "type whenever we use it, the type-checker leverages something called " +
                    "control flow analysis to deduce the type within every language " +
                    "construct.In previous versions of TypeScript, this would be an " +
                    "error – even though argIsString was assigned the value of a type " +
                    "guard, TypeScript simply lost that information. That’s unfortunate " +
                    "since we might want to re-use the same check in several places. " +
                    "To get around that, users often have to repeat themselves or " +
                    "use type assertions (casts).In TypeScript 4.4, that is no longer " +
                    "the case. The above example works with no errors! When TypeScript " +
                    "sees that we are testing a constant value, it will do a little bit " +
                    "of extra work to see if it contains a type guard. If that type guard " +
                    "operates on a const, a readonly property, or an un-modified parameter, " +
                    "then TypeScript is able to narrow that value appropriately.Different " +
                    "sorts of type guard conditions are preserved – not just typeof checks." +
                    "For example, checks on discriminated unions work like a charm.",
                    PublishedDate = DateTime.Now,
                    IsDeleted = false,
                    Published = true,
                    Category = categories.Single(x => x.Name == categories[2].Name),
                    Tags = new List<Tag>{tag1, tag5,tag3},
                    ImageSlider = "post-s-2.jpg",
                    ViewCount = 8,
                    RateCount = 6,
                    TotalRate = 68
                },
                new Post
                {
                    Id = Guid.NewGuid(),
                    Title = "How Do ToF Based Depth Cameras Improve Our Life",
                    UrlSlug = "how-do-tof-based-depth-cameras-improve-our-life",
                    ShortDescription = "The answer to this question really ",
                    ImageUrl = "blog-5.jpg",
                    PostContent = "In JavaScript, we often have to probe a variable " +
                    "in different ways to see if it has a more specific type that we " +
                    "can use. TypeScript understands these checks and calls them type " +
                    "guards. Instead of having to convince TypeScript of a variable’s " +
                    "type whenever we use it, the type-checker leverages something called " +
                    "control flow analysis to deduce the type within every language " +
                    "construct.In previous versions of TypeScript, this would be an " +
                    "error – even though argIsString was assigned the value of a type " +
                    "guard, TypeScript simply lost that information. That’s unfortunate " +
                    "since we might want to re-use the same check in several places. " +
                    "To get around that, users often have to repeat themselves or " +
                    "use type assertions (casts).In TypeScript 4.4, that is no longer " +
                    "the case. The above example works with no errors! When TypeScript " +
                    "sees that we are testing a constant value, it will do a little bit " +
                    "of extra work to see if it contains a type guard. If that type guard " +
                    "operates on a const, a readonly property, or an un-modified parameter, " +
                    "then TypeScript is able to narrow that value appropriately.Different " +
                    "sorts of type guard conditions are preserved – not just typeof checks." +
                    "For example, checks on discriminated unions work like a charm.",
                    PublishedDate = DateTime.Now,
                    IsDeleted = false,
                    Published = true,
                    Category = categories.Single(x => x.Name == categories[1].Name),
                    Tags = new List<Tag>{tag2,tag3},
                    ImageSlider = "post-s-1.jpg",
                    ViewCount = 88,
                    RateCount = 66,
                    TotalRate = 888
                },
                new Post
                {
                    Id = Guid.NewGuid(),
                    Title = "Now in private preview: optimize your data distribution with hierarchical partition keys",
                    UrlSlug = "now-in-private-preview-optimize-your-data-distribution-with-hierarchical-partition-keys",
                    ShortDescription = "There’s no specific number of categories ",
                    ImageUrl = "blog-6.jpg",
                    PostContent = "In JavaScript, we often have to probe a variable " +
                    "in different ways to see if it has a more specific type that we " +
                    "can use. TypeScript understands these checks and calls them type " +
                    "guards. Instead of having to convince TypeScript of a variable’s " +
                    "type whenever we use it, the type-checker leverages something called " +
                    "control flow analysis to deduce the type within every language " +
                    "construct.In previous versions of TypeScript, this would be an " +
                    "error – even though argIsString was assigned the value of a type " +
                    "guard, TypeScript simply lost that information. That’s unfortunate " +
                    "since we might want to re-use the same check in several places. " +
                    "To get around that, users often have to repeat themselves or " +
                    "use type assertions (casts).In TypeScript 4.4, that is no longer " +
                    "the case. The above example works with no errors! When TypeScript " +
                    "sees that we are testing a constant value, it will do a little bit " +
                    "of extra work to see if it contains a type guard. If that type guard " +
                    "operates on a const, a readonly property, or an un-modified parameter, " +
                    "then TypeScript is able to narrow that value appropriately.Different " +
                    "sorts of type guard conditions are preserved – not just typeof checks." +
                    "For example, checks on discriminated unions work like a charm.",
                    PublishedDate = DateTime.Now,
                    IsDeleted = false,
                    Published = true,
                    Category = categories.Single(x => x.Name == categories[0].Name),
                    Tags = new List<Tag>{tag6,tag3},
                    ImageSlider = "post-s-4.jpg",
                    ViewCount = 66,
                    RateCount = 16,
                    TotalRate = 68
                }
            };
            context.Categories.AddRange(categories);
            context.Posts.AddRange(posts);
            context.SaveChanges();
        
        }
        //Create User=Admin@Admin.com with password=Admin@123456 in the Admin role        
        public static void InitializeIdentity(JustBlogDbContext db)
        {
            var userManager = new UserManager<User>(new UserStore<User>(db));
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(db));
            const string name = "admin@example.com";
            const string password = "Admin@123456";
            const string roleName = "Admin";

            //Create Role Admin if it does not exist
            var role = roleManager.FindByName(roleName);
            if (role == null)
            {
                role = new IdentityRole(roleName);
                var roleResult = roleManager.Create(role);
            }

            var user = userManager.FindByName(name);
            if (user == null)
            {
                user = new User { UserName = name, Email = name };
                var result = userManager.Create(user, password);
                result = userManager.SetLockoutEnabled(user.Id, false);
            }

            // Add user admin to Role Admin if not already added
            var rolesForUser = userManager.GetRoles(user.Id);
            if (!rolesForUser.Contains(role.Name))
            {
                var result = userManager.AddToRole(user.Id, role.Name);
            }
        }
    }
}