[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(hLib.MVCGridConfig), "RegisterGrids")]

namespace hLib
{
    using System;
    using System.Web;
    using System.Web.Mvc;
    using System.Linq;
    using System.Collections.Generic;

    using MVCGrid.Models;
    using MVCGrid.Web;
    using DAL;
    using Models;

    public static class MVCGridConfig 
    {
        public static void RegisterGrids()
        {

            ColumnDefaults colDefauls = new ColumnDefaults()
            {
                EnableSorting = true
            };

            MVCGridDefinitionTable.Add("AuthorSearch", new MVCGridBuilder<Author>(colDefauls)
               .WithAuthorizationType(AuthorizationType.AllowAnonymous)
               .AddColumns(cols =>
               {
                   //            < a href = "@Url.Action("Details", new { id = item.BookId })" data - toggle = "tooltip" data - placement = "top" title = "book details" >

                   //                 <i class='glyphicon glyphicon-list'></i><span class='sr-only'>Details</span>
                   // 
                   //</a>

                   cols.Add("Delete").WithHtmlEncoding(false)
                    .WithSorting(false)
                    .WithHeaderText(" ")
                    .WithValueExpression(p =>  p.AuthorId.ToString() )
                    .WithValueTemplate("<a class='authorSelectLink' value='{Value}' ><i class='glyphicon glyphicon-arrow-left'></i><span class='sr-only'>Details</span></span> </a>");
                   //cols.Add("selectedBookAuthors").WithHtmlEncoding(false)
                   //  .WithSorting(false)
                   //  .WithHeaderText(" ")
                   //  .WithValueExpression(  p => p.AuthorId.ToString() )
                   //  .WithValueTemplate("<input type='checkbox' class='authorCheckBox' value='{Value}'></input>");
                   //cols.Add("Id").WithSorting(false)
                   //    .WithValueExpression(p => p.AuthorId.ToString());
                   cols.Add("AuthorFirstName").WithHeaderText("Name")
                       .WithValueExpression(p => p.AuthorFirstName);
                   cols.Add("AuthorMiddleName").WithHeaderText("Mid. name")
                       .WithValueExpression(p => p.AuthorMiddleName);
                   cols.Add("AuthorLastName").WithHeaderText("Last name")
                       .WithValueExpression(p => p.AuthorLastName);
                   /*cols.Add("Nationality").WithHeaderText("Name")
                       .WithValueExpression(p => p.Nationality.NationalityName.ToString());*/
               })
               .WithAdditionalQueryOptionNames("Search")
               .WithAdditionalSetting("RenderLoadingDiv", false)
               .WithSorting(true, "AuthorLastName")
               .WithPaging(true, 5)
               .WithRetrieveDataMethod((context) =>
               {
                   var options = context.QueryOptions;

                   int totalRecords;


                   var repo = new UnitOfWork(new DAL.HLibDBContext());
                   string globalSearch = options.GetAdditionalQueryOptionString("Search");

                   var items = repo.AuthorsRP.GetData(out totalRecords, globalSearch, options.SortColumnName, options.SortDirection == SortDirection.Dsc, options.GetLimitOffset(), options.GetLimitRowcount());
                   return new QueryResult<Author>()
                   {
                       Items = items,
                       TotalRecords = totalRecords
                   };
               })
           );           
        }
    }
}