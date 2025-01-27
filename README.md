# PurchaseForm
Автоматизатор заполнения закупочного акта ресторана

## Схема базы данных
```mermaid
erDiagram

    PurchaseForms }o--|| Suppliers : is
    PurchaseForms }|--|| PurchaseFormMerchandise : is
    PurchaseForms ||--|{ PurchaseVolumes : is
    PurchaseForms{
        guid id PK
        guid sponsorOrganizationId FK
        guid approvingOfficerId FK
        date documentDate
        int documentNumber
        guid procurementSpecialistId FK
        guid salesmanId FK
    }

    Organizations ||--o{ PurchaseForms : is
    Organizations |o--|{ Users : is
    Organizations{
        guid id PK
        string name
        string address
        string structuralUnit
        string INN
        string OKPO
        string OKDP
    }

    Suppliers ||--o{ SupplierMerchandises : is
    Suppliers{
        guid id PK
        string firstName
        string lastName
        string patronymic
        string address
        string INN
    }

    SupplierMerchandises{
        guid supplierId PK,FK
        guid merchandiseId PK,FK
        double price
    }

    PurchaseFormMerchandise{
        guid purchaseFormId PK
        guid merchandiseId PK
    }

    Merchandises }o--|| MeasurementUnits : is
    Merchandises ||--o{ PurchaseFormMerchandise : is
    Merchandises{
        guid id PK
        string name
        string merchandiseKey
        guid measurementUnitId FK
    }

    MeasurementUnits{
        guid id PK
        string name
        string OKEIKey
    }

    PurchaseVolumes{
        guid purchaseFormId PK,FK
        guid merchandiseId PK,FK
        guid supplierId PK,FK
        double price
        int count
    }

    Employees }o--|| EmployeePositions : is
    Employees{
        guid id PK
        guid PositionId FK
        string firstName
        string lastName
        string patronymic
        string jsonSignature
    }

    EmployeePositions{
        guid id PK
        string name
    }

    Users{
        guid id PK
        string phoneNumber PK
        string email PK
        guid organizationId FK
        string firstName
        string lastName
        string patronymic
        string password
    }
```
guid - уникальный идентификатор

## Роли пользователей
|   Роль    |                               Права                                     |
|-----------|-------------------------------------------------------------------------|
| Бухгалтер организации | Чтение товаров продавцов, чтение закупочных актов организации, создание, редактирование и удаление закупочных актов|
| Администратор организации | Чтение товаров продавцов, чтение закупочных актов организации, редактирование, удаление организации |
| Продавец | Чтение своих товаров и товаров других продавцов, чтение закупочных актов в которых он участвует|