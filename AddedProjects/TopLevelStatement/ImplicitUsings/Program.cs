Console.WriteLine("Hello, World!");
/* the following code will be added to the csproj file
 * // <ImplicitUsings>enable</ImplicitUsings> is used to enable implicit usings
	  // if you want to disable implicit usings, you can use <ImplicitUsings>disable</ImplicitUsings>
	  // if you exclude singls using you can use 
	  <ItemGroup>
		  <Using remove="System.Linq" />// this will remove System.Linq from implicit usings
		  <Using include="System.Linq" />// this will include System.Linq in implicit usings
	  </ItemGroup>
 */
