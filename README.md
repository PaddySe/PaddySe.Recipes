# README for PaddySe.Recipes

This is YARCS (Yet Another Recipe Collection Site). It's a simple site that allows users to create, edit, and delete recipes.

There is nothing special here. It is just a way for me to spend some time doing what I like to do, which is to write code.

I also use it as a way to learn and test new things.

If you want a mycht better and good-looking recipe site, try [Mealie](https://mealie.io/)!


## Getting Started

### Prerequisites

* .Net Core 8

Things will be added as I go along.

## Handy commands

### Create a new migration

Create a new migration using the following command:

`dotnet ef migrations add CreateIdentitySchema -p PaddySe.Recipes.DataAccess -o Migrations -c RecipesDbContext -s PaddySe.Recipes.Web`

### Update the database

Update the database using the following command:

`dotnet ef database update -p PaddySe.Recipes.DataAccess -c RecipesDbContext -s PaddySe.Recipes.Web`
dotnet ef database update -s PaddySe.Recipes.Web

## Ideas to (possibly) implement

- [ ] [Implement e-mail confirmations](https://learn.microsoft.com/en-us/aspnet/core/security/authentication/accconfirm?view=aspnetcore-8.0&tabs=visual-studio)
- [ ] [Implement Recipe schema](https://schema.org/Recipe)

