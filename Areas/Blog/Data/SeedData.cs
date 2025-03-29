using App.Models.Blog;
using Bogus;

namespace App.Areas.Blog.Data
{
    public class SeedData
    {
        private void SeedPostCate()
        {
            // trước khi phát sinh thì xóa các data cũ:
             //_dbContext.Categories.RemoveRange(_dbContext.Categories.Where(c => c.Description.Contains("[fakeData]")));

            var fakerData = new Faker<Category>();
            int cm = 1;
            fakerData.RuleFor(c => c.Title, fk => $"CM{cm++}" + fk.Lorem.Sentence(1,2).Trim('.'));
            fakerData.RuleFor(c => c.Content, fk => fk.Lorem.Sentences(5) + "[fakeData]"); // them "[fakeData]" de sau nay xoa hoac tim cac data seed
            fakerData.RuleFor(c => c.Slug, fk => fk.Lorem.Slug());

            var cate1 = fakerData.Generate();
                var cate11 = fakerData.Generate();
                var cate12 = fakerData.Generate();
            var cate2 = fakerData.Generate();
                var cate21 = fakerData.Generate();
                var cate22 = fakerData.Generate();
            cate11.ParentCategory = cate1;
            cate12.ParentCategory = cate1;
            cate21.ParentCategory = cate2;
            cate22.ParentCategory = cate2;
            var categories = new Category[] { cate1, cate11, cate12, cate2, cate21, cate22 };
            //_dbContext.Categories.AddRange(categories);     //*//
            
            // Dùng ở phần có DI DbContext.
        }
    }
}
