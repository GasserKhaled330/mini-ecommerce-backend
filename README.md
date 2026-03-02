# 🛒 E-Commerce System

A full-stack e-commerce application built with **ASP.NET Core 8** and **React**, focusing on robust validation, tiered discounts, and real-time stock management.

## 🚀 Quick Start

### 1. Prerequisites

- Backend: .NET 8 SDK
- Frontend: Node.js (v18+)
- Database: SQL Server (LocalDB or Express)

### 2. Backend Setup

**Example**:

```bash
# Clone the repository
git clone https://github.com/GasserKhaled330/mini-ecommerce-backend.git

cd mini-ecommerce-backend
```

Update the `appsettings.Development.json` file in the **Ecommerce.Api** project to your db connection string:

```json
"ConnectionStrings": {
  "DefaultConnection": "Server=(localdb)\\mssqllocaldb;Database=EcommerceDb;Trusted_Connection=True;"
}
```

```bash
# Navigate to the Infrastrcuture project
cd ecommerce-backend/src/Ecommerce.Infrastrcuture

# Update the database (Ensure ConnectionString in appsettings.json is correct)
dotnet ef database update --startup-project ../Ecommerce.Api
```

```bash
# Navigate to the API project
cd ecommerce-backend/src/Ecommerce.Api

# Run the API
dotnet run
```

The API will be available at `http://localhost:5010/api` (check your `launchSettings.json`).

to see it on swagger will be available at `http://localhost:5010/swagger/index.html`.

### 3. Frontend Setup

```bash
# Navigate to the frontend folder
cd ecommerce-frontend

# Install dependencies using npm
npm install

# Install dependencies using pnpm
pnpm install

# Start the development server
npm run dev

# or
pnpm dev
```

The UI will be available at `http://localhost:5173`.
