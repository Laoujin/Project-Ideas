log4net
=======
Competitors: NLog, Serilog, ELMAH

Install-Package log4net

Start:  
`[assembly: log4net.Config.XmlConfigurator(ConfigFile="log4net.config", Watch=true)]`  
or  
`log4net.Config.XmlConfigurator.Configure();`

Usage:  
```
private static readonly ILog Logger = LogManager.GetLogger(typeof(ExceptionFilterAttribute));
Logger.Error(ex.ToString());
```

Config:  
```
<configSections>
    <section name="log4net" type="log4net.Config.Log4NetConfigurationSectionHandler, log4net" />
</configSections>

<log4net>
    <appender name="RollingLogFileAppender" type="log4net.Appender.RollingFileAppender">
      <lockingModel type="log4net.Appender.FileAppender+MinimalLock" />
      <file type="log4net.Util.PatternString" value="logs\log_%date{yyyyMMdd}.log" />
      <appendToFile value="true" />
      <rollingStyle value="Date" />
      <datePattern value="yyyyMMdd" />
      <layout type="log4net.Layout.PatternLayout">
        <conversionPattern value="%date [%thread] %-5level %logger [%property{NDC}] – %message%newline" />
      </layout>
    </appender>
    <appender name="RollingLogFileAppender" type="log4net.Appender.RollingFileAppender">
      <file value="C:\rolling-log.txt" />
      <appendToFile value="true" />
      <maxSizeRollBackups value="10" />
      <maximumFileSize value="100" />
      <rollingStyle value="Size" />
      <staticLogFileName value="true" />
      <layout type="log4net.Layout.PatternLayout">
        <header value="[Header]&#13;&#10;" />
        <footer value="[Footer]&#13;&#10;" />
        <conversionPattern value="%date [%thread] %-5level %logger [%ndc] - %message%newline" />
      </layout>
    </appender>
    <appender name="LogFileAppender" type="log4net.Appender.FileAppender">
      <file value="C:\log-file.txt" />
      <appendToFile value="true" />
      <layout type="log4net.Layout.PatternLayout">
        <header value="[Header]&#13;&#10;" />
        <footer value="[Footer]&#13;&#10;" />
        <conversionPattern value="%date [%thread] %-5level %logger [%ndc] &lt;%property{auth}&gt; - %message%newline" />
      </layout>
    </appender>
    <root>
      <level value="ALL" />
      <appender-ref ref="LogFileAppender" />
      <appender-ref ref="RollingLogFileAppender" />
    </root>
</log4net>
```

Spit out current log file contents:  
Requires: <lockingModel type="log4net.Appender.FileAppender+MinimalLock" />

```
public HttpResponseMessage GetLogging()
{
   FileAppender rootAppender = ((Hierarchy)LogManager.GetRepository())
       .Root.Appenders.OfType<FileAppender>()
       .FirstOrDefault();

   var resp = new HttpResponseMessage(HttpStatusCode.OK);
   
   if (rootAppender == null)
   {
       resp.Content = new StringContent("No log4net FileAppender configured!", System.Text.Encoding.UTF8, "text/plain");
   }
   else
   {
       resp.Content = new StringContent(System.IO.File.ReadAllText(rootAppender.File), System.Text.Encoding.UTF8, "text/plain");
   }
   return resp;
}
```