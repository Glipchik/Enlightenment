import { ReactNode, useState } from "react";
import { Sidebar, Menu, MenuItem, MenuItemStyles } from "react-pro-sidebar";
import { Box, IconButton, Typography, useTheme } from "@mui/material";
import { NavLink } from "react-router-dom";
import { tokens } from "../../../theme";
import {
  DashboardOutlined,
  BookOutlined,
  BookmarksOutlined,
  MenuOutlined,
} from "@mui/icons-material";
import * as routes from "../../../constants/routes";
import "./NavMenu.component.css";

type ItemProps = {
  title: string;
  to: string;
  icon: ReactNode;
};

function Item({ title, to, icon }: ItemProps) {
  const theme = useTheme();
  const colors = tokens(theme.palette.mode);
  return (
    <MenuItem component={<NavLink to={to} />} style={{ color: colors.grey[100] }} icon={icon}>
      <Typography>{title}</Typography>
    </MenuItem>
  );
}

export default function NavMenu() {
  const theme = useTheme();
  const colors = tokens(theme.palette.mode);
  const [isCollapsed, setIsCollapsed] = useState(false);

  const menuItemsStyles: MenuItemStyles = {
    button: {
      padding: "5px 20px",
      color: colors.blueAccent[500],
      "&.active": {
        color: `${colors.blueAccent[500]} !important`,
      },
      "&:hover *": {
        color: `${colors.blueAccent[400]} !important`,
      },
      "&:hover": {
        backgroundColor: "transparent !important",
      },
    },
    root: {
      backgroundColor: `${colors.primary[400]} !important`,
    },
    icon: {
      backgroundColor: "transparent !important",
    },
  };

  return (
    <Box className="sticky">
      <Sidebar
        rootStyles={{ border: 0 }}
        backgroundColor={colors.primary[400]}
        style={{
          minWidth: isCollapsed ? "80px" : "200px",
          height: "100%",
        }}
        collapsed={isCollapsed}
      >
        <Menu menuItemStyles={menuItemsStyles}>
          <MenuItem
            style={{
              margin: "10px 0 20px 0",
              color: colors.grey[100],
              cursor: "default",
            }}
          >
            <Box className="collapse">
              <IconButton onClick={() => setIsCollapsed(!isCollapsed)}>
                <MenuOutlined />
              </IconButton>
              {!isCollapsed ? <Typography variant="h4">Enlightenment</Typography> : undefined}
            </Box>
          </MenuItem>
          <Item title="Dashboard" to={routes.Dashboard.main} icon={<DashboardOutlined />} />
          <Item title="Modules" to={routes.Modules.main} icon={<BookOutlined />} />
          <Item title="Paths" to={routes.Paths.main} icon={<BookmarksOutlined />} />
        </Menu>
      </Sidebar>
    </Box>
  );
}
