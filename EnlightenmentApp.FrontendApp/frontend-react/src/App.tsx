import { ColorModeContext, useMode } from "./theme";
import { CssBaseline, ThemeProvider } from "@mui/material";
import { Routes, Route, Navigate } from "react-router-dom";
import NavMenu from "./scenes/global/NavMenu/NavMenu";
import Topbar from "./scenes/global/Topbar/Topbar";
import Dashboard from "./scenes/Dashboard/Dashboard";
import Modules from "./scenes/Modules/Modules";
import * as routes from "./constants/routes";

function App() {
  const [theme, colorMode] = useMode();
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
