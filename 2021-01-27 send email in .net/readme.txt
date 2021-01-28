.NET Framework used to use SmtpClient, which read this from the app.config/web.config file:

<mailSettings>
    <smtp deliveryMethod="Network">
      <network host="my-host" port="587" userName="my-user" password="my-password" 
               enableSsl="true" defaultCredentials="false" />
    </smtp>
</mailSettings>

Microsoft has deprecated SmtpClient, and they recommend a library like MailKit.

Here's a full example of MailKit:
https://dotnetcoretutorials.com/2017/11/02/using-mailkit-send-receive-email-asp-net-core/
