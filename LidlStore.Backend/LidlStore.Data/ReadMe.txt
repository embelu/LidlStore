-----------------------------------------------------------------------------------------------------------
 SCAFFOLDING
-----------------------------------------------------------------------------------------------------------

Scaffold-DbContext "Server=S319SQLT1\DEVSQL319;Database=DB_Formation;Trusted_Connection=True;" Microsoft.EntityFrameworkCore.SqlServer -t Lidl_Categorie_LB, Lidl_Produit_LB, Lidl_Commande_LB, Lidl_DetailCommande_LB -OutputDir Entities -Force

Nugget's nécessaires pour Scaffolding : 
EntityFrameworkCore.SqlServer
Microsoft.EntityFrameworkCore.Tools
Microsoft.EntityFrameworkCore.Design

-----------------------------------------------------------------------------------------------------------
 SWAGGER
-----------------------------------------------------------------------------------------------------------

Nugget's nécessaires pour Scaffolding : 
Swashbuckle.AspNetCore





