# MacIdeaDemo
Message Authentication Code (MAC) Idea demo
These types of cryptographic primitive can be distinguished by the security goals they fulfill (in the simple protocol of "appending to a message"):

Integrity: Can the recipient be confident that the message has not been accidentally modified?

Authentication: Can the recipient be confident that the message originates from the sender?

Non-repudiation: If the recipient passes the message and the proof to a third party, can the third party be confident that the message originated from the sender? (Please note that I am talking about non-repudiation in the cryptographic sense, not in the legal sense.) Also important is this question:

Keys: Does the primitive require a shared secret key, or public-private keypairs? I think the short answer is best explained with a table:

Cryptographic primitive | Hash |    MAC    | Digital
Security Goal           |      |           | signature
------------------------+------+-----------+-------------
Integrity               |  Yes |    Yes    |   Yes
Authentication          |  No  |    Yes    |   Yes
Non-repudiation         |  No  |    No     |   Yes
------------------------+------+-----------+-------------
Kind of keys            | none | symmetric | asymmetric
                        |      |    keys   |    keys
Please remember that authentication without confidence in the keys used is useless. For digital signatures, a recipient must be confident that the verification key actually belongs to the sender. For MACs, a recipient must be confident that the shared symmetric key has only been shared with the sender.

https://crypto.stackexchange.com/questions/5646/what-are-the-differences-between-a-digital-signature-a-mac-and-a-hash?newreg=90481a425fb14ff0a7250cde651e77e8
