namespace ReactSignalR.StartUp
{
	using Microsoft.Owin.FileSystems;
	using Microsoft.Owin.StaticFiles;

	using Owin;

	public class StaticContentRegistration
	{
		public static void Register(IAppBuilder app)
		{
			var physicalFileSystem = new PhysicalFileSystem(@"./");
			var options = new FileServerOptions
			{
				EnableDefaultFiles = true,
				FileSystem = physicalFileSystem
			};
			options.StaticFileOptions.FileSystem = physicalFileSystem;
			options.StaticFileOptions.ServeUnknownFileTypes = true;
			options.DefaultFilesOptions.DefaultFileNames = new[]
			{
				"index.html"
			};

			app.UseFileServer(options);
		}
	}
}