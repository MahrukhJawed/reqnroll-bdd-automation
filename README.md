![GitHub top language](https://img.shields.io/github/languages/top/MahrukhJawed/reqnroll-bdd-automation) 
![Static Badge](https://img.shields.io/badge/selenium%20C%23-Reqnroll-darkblue) ![Static Badge](https://img.shields.io/badge/formerly-Specflow-orange) ![GitHub Downloads (all assets, all releases)](https://img.shields.io/github/downloads/MahrukhJawed/reqnroll-bdd-automation/total)
![GitHub License](https://img.shields.io/github/license/MahrukhJawed/reqnroll-bdd-automation) ![GitHub forks](https://img.shields.io/github/forks/MahrukhJawed/reqnroll-bdd-automation)
![Static Badge](https://img.shields.io/badge/BDD%20Automation%20Framework-red) ![GitHub User's stars](https://img.shields.io/github/stars/MahrukhJawed)

# reqnroll-bdd-automation

A robust BDD automation framework built with C#, leveraging [Reqnroll](https://reqnroll.net/) (SpecFlow fork), Selenium WebDriver, Page Object Model (POM), Allure reporting, and GitHub Actions CI/CD.

---

## Key Features

### 1. Reqnroll (formerly Specflow) BDD Framework

- Uses [Reqnroll](https://reqnroll.net/) for Behavior-Driven Development.
- Write feature files in Gherkin syntax for clear, business-readable test scenarios.
- Step definitions are implemented in C# for seamless integration with the application logic.

### 2. Environment Management via Property File

- Environment-specific data (e.g., browser, base URL, credentials) is maintained in a single `environment.properties` file under `resources/`.
- The `Setup` helper class loads these properties at runtime, making it easy to switch environments or update test data without code changes.

### 3. Page Object Model (POM)

- Implements the Page Object Model design pattern for maintainable and reusable UI automation.
- Each page (e.g., `LoginPage`, `MyInfoPage`, `LogoutPage`) encapsulates its elements and actions.
- Centralized object management via the `Objects` container.

### 4. Allure Report Integration

- Generates rich, interactive test reports using [Allure](https://docs.qameta.io/allure/).
- Allure is configured via the `Allure.Reqnroll` NuGet package.

### 5. Logging

- Uses [log4net](https://logging.apache.org/log4net/) for detailed logging.
- Log configuration is managed in `Config/LoggerConfigure.xml`.
- Logs are written to the `Logs/` directory in the test output, capturing key events and errors.

### 6. GitHub CI/CD Workflow

- Automated test execution via GitHub Actions.
- Allure reports are published to GitHub Pages after each workflow run.

### 7. Selenium WebDriver Manager

- Uses [WebDriverManager](https://github.com/rosolko/WebDriverManager.Net) to automatically download and manage browser drivers.
- No manual driver setup required; 
---

## Getting Started

1. **Clone the repository**
3. **Run tests** using your preferred test runner (e.g., Visual Studio Test Explorer, `dotnet test`).
4. **View Allure reports** locally or via GitHub Pages after CI runs.

- To view Allure reports locally, run the following command in the terminal:
1. allure generate allure-results -o allure-report
2. allure open

- To view Allure reports on GitHub Pages, 
1. Navigate to the `gh-pages` branch of the repository after a CI run.
2. Alternatively, you can access the reports directly from the GitHub Pages URL configured in the repository settings.
3. ![image](https://github.com/user-attachments/assets/51c37e9a-378b-4c19-99d4-db802fb58f5c)
4. ![image](https://github.com/user-attachments/assets/7934b64b-7ed7-44d6-a5a5-4047d44c69e6)
5. ![image](https://github.com/user-attachments/assets/c761cf97-8bfa-4d29-ba23-004678cb54d1)


