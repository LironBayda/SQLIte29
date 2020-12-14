# SQLIte29

SQL #29 Answers 

1. SQL aliases are used to give a table or a column in a table, a temporary name. 
2. Because sometimes we have columns in two different table with the same name.
3. POCO stand for Plain Old C# Object. It contains fields that match to the columns in the SQL table.  We use it to create c# object from SQL content.  
4. DAO is a pattern that provide abstract interface to the database. it provides data operation without exposing details of the database. 
5. Yes. Because we create c# objects from the data in the database and put these objects in the list- c# objects remain when the database closed.
6. Because SQLITE return object.
7. LINQ query is a way to extract information, usually from list.  you sould use it because it simple and short
8. the two syntax types are:
- SQL syntax
- .ForEach(x=>some operation to perform on x)
9.(x=>new {}) for example:
 var result = tickets.GroupBy(t => t.EventName)
                    .Select(g  => new { 
                             EventName = g.Key, 
                             TicketCount = g.Sum(t => t.TicketCount), 
                             Price = g.Sum(t => t.Price)
                    });
It can help us get data from the database like we see in the example.

