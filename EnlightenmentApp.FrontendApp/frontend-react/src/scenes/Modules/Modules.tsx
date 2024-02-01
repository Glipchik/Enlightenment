import {
  Grid,
  Card,
  CardActionArea,
  CardContent,
  CardMedia,
  CardActions,
  Button,
  Typography,
  Box,
  Chip,
  Fade,
  LinearProgress,
} from "@mui/material";
import { TollOutlined } from "@mui/icons-material";
import ModuleService from "../../data/services/ModuleService";
import { useEffect, useState } from "react";
import Module from "../../data/models/Module/Module";
import "./Modules.component.css";
import Header from "../global/Header/Header";
import Tag from "../../data/models/Tag/Tag";

export default function Modules() {
  const [loaded, setLoaded] = useState(false);
  let _moduleService = new ModuleService();
  const [data, setData] = useState([] as Module[]);
  useEffect(() => {
    _moduleService.get().then((res) => {
      setData(res);
      setLoaded(true);
    });
  }, [setData, setLoaded, _moduleService]);
  return (
    <Box>
      <Box m="20px">
        <Header title="MODULES" />
      </Box>
      <Fade in={!loaded} timeout={500}>
        <LinearProgress color="secondary" />
      </Fade>

      <Box padding={4}>
        <Grid container spacing={4}>
          {data.map((module, index) => (
            <Grid item xs={12} sm={6} md={4}>
              <Card key={`card_${index}`} sx={{ maxWidth: 400 }}>
                <CardActionArea>
                  <CardMedia
                    component="img"
                    className="card-image"
                    image={module.imageSrc}
                    alt={module.title}
                  />
                  <CardContent className="card-content">
                    <Typography gutterBottom variant="h5" component="div">
                      {module.title}
                    </Typography>
                    <Box className="tag-container">
                      {module.tags.length > 0
                        ? module.tags
                            .sort((a, b) => compareTagType(a, b))
                            .map((tag, tagInd) => {
                              let color: string = parseTagStyles(tag).color;
                              return (
                                <Box pt="4px" pr="8px">
                                  <Chip
                                    key={`chip_${index}_${tagInd}`}
                                    size="small"
                                    label={tag.value}
                                    className="card-tag"
                                    sx={
                                      color
                                        ? {
                                            borderColor: color,
                                            color: color,
                                          }
                                        : undefined
                                    }
                                    variant="outlined"
                                  ></Chip>
                                </Box>
                              );
                            })
                        : ""}
                    </Box>
                  </CardContent>
                </CardActionArea>
                <CardActions>
                  <Button
                    sx={{ justifyContent: "center" }}
                    variant="contained"
                    size="small"
                    color="primary"
                  >
                    <TollOutlined fontSize="small" color="secondary" />
                    <Typography variant="button">{`${module.cost} Unlock`}</Typography>
                  </Button>
                </CardActions>
              </Card>
            </Grid>
          ))}
        </Grid>
      </Box>
    </Box>
  );

  function compareTagType(a: Tag, b: Tag): number {
    let value = (el: Tag) => {
      return (el.type ||= Infinity);
    };
    return value(a) - value(b);
  }

  function parseTagStyles(tag: Tag) {
    let styles: any = {};
    try {
      styles = JSON.parse(tag.metaData);
    } catch (e) {}
    return styles;
  }
}
