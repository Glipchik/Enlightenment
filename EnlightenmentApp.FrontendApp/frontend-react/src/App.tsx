import React from "react";
import logo from "./logo.svg";
import "./App.css";
import Home from "./components/Home";

function App() {
  return (
    <ColorModeContext.Provider value={colorMode}>
      <ThemeProvider theme={theme}>
        <CssBaseline />
        <div className="app">
          <NavMenu />
          <main className="content">
            <Topbar />
            <Routes>
              <Route path={routes.Dashboard.main} key={"dashboard_0"} element={<Dashboard />} />
              {routes.Dashboard.alias.map((path, index) => (
                <Route
                  path={path}
                  element={
                    <Navigate to={routes.Dashboard.main} key={`dasboard_${index + 1}`} replace />
                  }
                />
              ))}
              <Route path={routes.Modules.main} key={"modules_0"} element={<Modules />} />
              {routes.Modules.alias.map((path, index) => (
                <Route
                  path={path}
                  element={
                    <Navigate to={routes.Modules.main} key={`modules_${index + 1}`} replace />
                  }
                />
              ))}
            </Routes>
          </main>
        </div>
      </ThemeProvider>
    </ColorModeContext.Provider>
  );
}

export default App;
