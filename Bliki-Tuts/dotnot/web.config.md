Transformations
---------------
Visual Studio Extension: SlowCheetah (Preview Web Transformations)
Visual Studio Extension: ConfigurationSectionDesigner (Custom web.config Sections)
--> Adding 'xmlns="urn:Macadam.PitStop.Core.Config"' = intellisense for web.config section(s) but then cannot do transformations?

<configuration xmlns:xdt="http://schemas.microsoft.com/XML-Document-Transform">
<connectionStrings>
	<add name="ttc"
		connectionString="connection"
		xdt:Transform="SetAttributes" xdt:Locator="Match(name)"/>
</connectionStrings>

<applicationSettings>
	<Program1.Properties.Settings>
		<setting name="CustomerId" serializeAs="String" xdt:Transform="Replace" xdt:Locator="Match(name)">
			<value>Customer2-343242</value>
		</setting>
	</Program1.Properties.Settings>
</applicationSettings>

xdt:Transform
-------------
Replace
SetAttributes
