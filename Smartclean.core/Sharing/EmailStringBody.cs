using System;
using System.Net;

namespace Smartclean.core.Sharing
{
    public class EmailStringBody
    {
        public static string send(string email, string token, string component, string message)
        {
            var encodedEmail = Uri.EscapeDataString(email);
            var encodedToken = Uri.EscapeDataString(token);
            var verificationLink = $"{component}?email={encodedEmail}&token={encodedToken}";
            var safeMessage = WebUtility.HtmlEncode(message);

            return $"""
                <!DOCTYPE html>
                <html lang="de">
                <head>
                    <meta charset="UTF-8">
                    <meta name="viewport" content="width=device-width, initial-scale=1.0">
                    <title>Willkommen bei SmartClean</title>
                </head>
                <body style="margin:0; padding:24px; background-color:#f4f7f6; font-family:Arial, sans-serif; color:#263238;">
                    <div style="max-width:600px; margin:0 auto; background-color:#ffffff; border-radius:10px; overflow:hidden;">
                        <div style="padding:28px; background-color:#2c7a7b; color:#ffffff;">
                            <h1 style="margin:0; font-size:26px;">Willkommen bei SmartClean</h1>
                            <p style="margin:8px 0 0;">Professionelle Reinigung, auf die Sie sich verlassen können.</p>
                        </div>

                        <div style="padding:30px; line-height:1.6;">
                            <p>Guten Tag,</p>

                            <p>{safeMessage}</p>

                            <p>
                                vielen Dank für Ihre Registrierung bei <strong>SmartClean</strong>.
                                Ihr Kundenkonto wurde erfolgreich erstellt. Mit Ihrem Konto können
                                Sie unsere Reinigungsleistungen bequem anfragen und verwalten.
                            </p>

                            <p style="text-align:center; margin:32px 0;">
                                <a href="{verificationLink}"
                                   style="display:inline-block; padding:13px 24px; background-color:#2c7a7b;
                                          color:#ffffff; text-decoration:none; border-radius:5px;">
                                    E-Mail-Adresse bestätigen
                                </a>
                            </p>

                            <p>
                                Falls Sie diese Registrierung nicht vorgenommen haben, können Sie
                                diese E-Mail einfach ignorieren.
                            </p>

                            <p>
                                Wir freuen uns darauf, Sie mit einem zuverlässigen und gründlichen
                                Reinigungsservice zu unterstützen.
                            </p>

                            <p>
                                Mit freundlichen Grüßen<br>
                                <strong>Ihr SmartClean-Team</strong><br>
                                Professionelle Reinigungsdienstleistungen
                            </p>
                        </div>

                        <div style="padding:18px 30px; background-color:#f4f7f6; color:#607d8b; font-size:12px;">
                            Diese E-Mail wurde automatisch von SmartClean versendet.
                            Bei Fragen können Sie uns über Ihre registrierte E-Mail-Adresse kontaktieren.
                        </div>
                    </div>
                </body>
                </html>
                """;
        }
    }
}
