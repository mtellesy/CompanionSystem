example of using get methods 

first you need to get the data
  'var results = await t.getUsers();'

 then you can quary on the returnd data for the data you net like 
 results.Select() for select


 this is how get methods looks like 

 public static async Task<List<String>> getUsers()
        {
		//here fist we get the entities from the table
         var entities = await DBuilder._connection.Table<Users>().ToListAsync(); 
		 // we convert them into results after we select only the data we want
         List<String>   results = entities.Select(i => i.Use_nameEN).ToList();
		
         return results;
        }