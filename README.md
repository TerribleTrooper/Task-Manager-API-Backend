# Task Manager API Backend

Backend API для управления задачами, написанный на **ASP.NET Core (.NET 8)**  
с поддержкой **JWT-аутентификации**, **чистой архитектуры**, **Docker** и **CI (GitHub Actions)**.

---

## Основные возможности

- JWT Authentication
- Регистрация и логин пользователей
- CRUD для задач
- Clean Architecture (Controllers / Services / Repositories)
- Глобальный Exception Handling
- Docker & docker-compose
- Unit tests
- CI (GitHub Actions)

---

## Технологии

- **.NET 8**
- **ASP.NET Core Web API**
- **Entity Framework Core**
- **PostgreSQL**
- **JWT**
- **Docker**
- **GitHub Actions (CI)**

---

## API
- POST AuthControllers/login
- POST AuthControllers/register

- POST /task        -> create
- GET /tasks        -> read
- DELETE /tasks{id} -> delete
- PATCH /tasks{id}  -> update

## Структура проекта

```text
Task-Manager-API-Backend
├── Controllers        # HTTP endpoints
├── Services           # Бизнес-логика
├── Repositories       # Работа с БД
├── Models             # Entity модели
├── DTOs               # Data Transfer Objects
├── Middleware         # Exception handling
├── Data               # DbContext & Migrations
├── Exceptions         # Кастомные исключения
├── Tests              # Unit tests
├── .github/workflows  # CI pipeline
└── Dockerfile
