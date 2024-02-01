import { Typography, Box, useTheme } from "@mui/material";
import { tokens } from "../../../theme";

export default function Header(props: { title: string; subtitle?: string }) {
  const theme = useTheme();
  const colors = tokens(theme.palette.mode);
  return (
    <Box>
      <Typography variant="h2" color={colors.grey[100]} fontWeight="bold" sx={{ mb: "5px" }}>
        {props.title}
      </Typography>
      <Typography variant="h5" color={colors.greenAccent[400]}>
        {props.subtitle}
      </Typography>
    </Box>
  );
}
