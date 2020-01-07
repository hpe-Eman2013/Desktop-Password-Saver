App.config Setup
--You must add these properties to the App.config file running this library:
	<configSections> </configSections>
	--Within this property, will contain a name called "section" and is defined like this:
	<section name="entityFramework"
          type="System.Data.Entity.Internal.ConfigFile.EntityFrameworkSection, EntityFramework, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"
          requirePermission="false"/>
	--EntityFramework must be added via Nuget Package Manager in order for this library to work.
	<entityFramework> </entityFramework>
	--Within this property, will contain the "providers" and "provider" sections defined like this:
	<entityFramework>
		<providers>
		  <provider invariantName="System.Data.SqlClient" type="System.Data.Entity.SqlServer.SqlProviderServices, EntityFramework.SqlServer"/>
		</providers>
	</entityFramework>
	--Lastly, within the this property, will contain the "connectionStrings" section that defines the location of the database like this:
	<connectionStrings>
        <add name="PasswordTrackingEntities" connectionString="metadata=res://*/ModelContext.csdl|res://*/ModelContext.ssdl|res://*/ModelContext.msl;provider=System.Data.SqlClient;provider connection string=&quot;data source=(localdb)\mssqllocaldb;initial catalog=PasswordTracking;integrated security=True;MultipleActiveResultSets=True;App=EntityFramework&quot;" providerName="System.Data.EntityClient" />
    </connectionStrings>
--Once these properties are added to the App.config file you should be able to access your database.