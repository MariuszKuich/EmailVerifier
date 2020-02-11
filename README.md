## EmailVerifier
'EmailVerifier' to aplikacja konsolowa napisana w języku C#. Użytkownik podaje adres e-mail, a aplikacja sprawdza:
* czy składnia podanego adresu e-mail jest poprawna,
* czy komunikacja z podanym adresem poczty elektronicznej przebiega poprawnie,
* jakość danego adresu poczty elektronicznej (skala 0-1, kryteria: dostarczalność, nazwa użytkownika i domeny)

Aplikacja łączy się z usługą Mailboxlayer (korzystając z udostępnionego API), pobiera z niej dane w formacie JSON, przetwarza je i prezentuje użytkownikowi.  
W projekcie wykorzystane zostały biblioteki RestSharp oraz Newtonsoft.Json.
