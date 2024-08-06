using Elmurod.ToDoList.Data;
using Elmurod.ToDoList.Models;
using System.Transactions;
//Connecting
UserPlans userPlans = new UserPlans();
AppDbContext appDbContext = new AppDbContext();
//
Console.WriteLine("===| TO |=| DO |=| LIST |===");
Console.WriteLine();

//Get Plans
Console.WriteLine("YOUR PLANS");
Console.WriteLine();
IEnumerable<UserPlans> userplans = appDbContext.Userplans.Where(t => t.Id > 0);

foreach (UserPlans userpl in userplans)
{
    Console.WriteLine("ID::" + userpl.Id);
    Console.WriteLine("Title: " + userpl.Title);
    Console.WriteLine("Description: " + userpl.Description);
    Console.WriteLine("Date: " + userpl.Date);
    Console.WriteLine();
}

//
Console.WriteLine("1: New Plan");
Console.WriteLine("2: Update Plan");
Console.WriteLine("3: Delete Plan");
Console.WriteLine("4: Complete Plan");
Console.WriteLine("5: NotCompleted Plans");
Console.WriteLine("6: Completed Plans");

Console.WriteLine("Enter a number: ");
string user = Console.ReadLine();
//Check something

if (user == "1")
{
    Console.WriteLine();
    Console.WriteLine("CREATE PLAN");
    Console.WriteLine();
    //Title
    do
    {
        Console.WriteLine("Title: ");
        string Title = Console.ReadLine();
        if (Title == string.Empty)
            continue;
        else if (Title != string.Empty)
        {
            userPlans.Title = Title;
            break;
        }
    } while (true);
    //Description
    do
    {
        Console.WriteLine();
        Console.WriteLine("Write Description: ");
        string Description = Console.ReadLine();
        if (Description == string.Empty)
            continue;
        else if (Description != string.Empty)
        {
            userPlans.Description = Description;
            break;
        }
    } while (true);
    //Date
    DateTime date = DateTime.UtcNow;
    userPlans.Date = date;
    //

    appDbContext.Userplans.Add(userPlans);
    
    appDbContext.SaveChanges();
    Console.WriteLine();
    Console.WriteLine("Completed!");
}
else if (user == "2")
{
    Console.WriteLine();
    Console.WriteLine("UPDATE PLAN");
    Console.WriteLine();
    Console.WriteLine("Enter plan's ID: ");
        int plansId = Convert.ToInt32(Console.ReadLine());
        UserPlans userplan = appDbContext.Userplans.Find(plansId);
    //
    do
    {
        Console.WriteLine();
        Console.WriteLine("Title: ");
        string updTitle = Console.ReadLine();
        if( updTitle == string.Empty)
            continue;
        else if( updTitle != string.Empty)
        {
            userplan.Title = updTitle;
            break;
        }
    } while (true);
    //
    do
    {
        Console.WriteLine();
        Console.WriteLine("Description: ");
        string updDescription = Console.ReadLine();
        if( updDescription == string.Empty)
            continue;
        else if(updDescription != string.Empty)
        {
            userplan.Description = updDescription;
            break;
        }
    } while (true);
    //
    appDbContext.SaveChanges();
    Console.WriteLine();
    Console.WriteLine("Updated!");

}
else if(user == "3")
{
    Console.WriteLine();
    Console.WriteLine("DELETE PLAN");
    Console.WriteLine();
    Console.WriteLine("Enter Plan's ID: ");
    int planiddlt = Convert.ToInt32(Console.ReadLine());
    UserPlans userplanDlt = appDbContext.Userplans.Find(planiddlt);
    //
    do
    {
        Console.WriteLine();
        Console.WriteLine("Reason to delete Plan: ");
        string planReason = Console.ReadLine();
        if (planReason == string.Empty)
        {
            continue;
        }
        else if (planReason != string.Empty)
        {
            UserPlans userPlansdlt = appDbContext.Userplans.Find(planiddlt);
            DeletedPlans deletedPlans = new DeletedPlans();
            DateTime dltDate = DateTime.UtcNow;
            deletedPlans.Reason = "Title: " + userplanDlt.Title + " Reason: " + planReason;
            deletedPlans.DeletedDate = dltDate;
            appDbContext.Deletedplans.Add(deletedPlans);
            //
            appDbContext.Userplans.Remove(userplanDlt);
            appDbContext.SaveChanges();
            

            Console.WriteLine();
            Console.WriteLine("Deleted!");
            break;
        }

    } while (true);
}
else if(user == "4")
{
    Console.WriteLine();
    Console.WriteLine("COMPLETE PLAN");
    Console.WriteLine();
    Console.WriteLine("Enter ID of Completed Plan: ");
    int compId = Convert.ToInt32(Console.ReadLine());
    UserPlans userplan = appDbContext.Userplans.Find(compId);
    do
    {
        if (compId <= 0)
            continue;
        else if (compId >= 1)
        {
            CompletedPlans completedPlans = new CompletedPlans();
            DateTime compDate = DateTime.UtcNow;
            completedPlans.Title = "COMPLETED::" + userplan.Title;
            completedPlans.Description = userplan.Description;
            completedPlans.CompletedDate = compDate;
            appDbContext.Completedplans.Add(completedPlans);

            appDbContext.Userplans.Remove(userplan);
            appDbContext.SaveChanges();
            Console.WriteLine();
            Console.WriteLine("Completed!");
            break;
        }
    }while(true);
}
else if(user == "5")
{
    Console.WriteLine();
    Console.WriteLine("YOUR NOTCOMPLETED PLANS");
    Console.WriteLine();
    IEnumerable<DeletedPlans> Getdeletedplans = appDbContext.Deletedplans.Where(t => t.Id > 0);

    foreach (DeletedPlans deletedPln in Getdeletedplans)
    {
        Console.WriteLine("ID::" + deletedPln.Id);
        Console.WriteLine("Reason: " + deletedPln.Reason);
        Console.WriteLine("Deleted Date: " + deletedPln.DeletedDate);
        Console.WriteLine();
    }
}
else if(user == "6")
{
    Console.WriteLine();
    Console.WriteLine("YOUR COMPLETED PLANS");
    Console.WriteLine();
    IEnumerable<CompletedPlans> Getcompletedplans = appDbContext.Completedplans.Where(t => t.Id > 0);

    foreach (CompletedPlans compPln in Getcompletedplans)
    {
        Console.WriteLine("ID::" + compPln.Id);
        Console.WriteLine("Title: " + compPln.Title);
        Console.WriteLine("Descripton: " + compPln.Description);
        Console.WriteLine("Completed Date: " + compPln.CompletedDate);
        Console.WriteLine();
    }
    UserPlans userPlans23 = new UserPlans();
    userPlans23.Id = 0;
    appDbContext.SaveChanges();
    Console.WriteLine("OHSHIT");

}
else if(user == "7")
{
    UserPlans userPlans1 = new UserPlans();
    userPlans1.Id = 0;
    appDbContext.SaveChanges();
}
