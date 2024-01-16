import React, { useEffect, useState } from "react";
import Axios from "axios";

export default function Home() {
  const apiServer = process.env["services__enlightenmentapp.api__1"];
  let [info, setInfo] = useState(String);
  Axios.get(`http://localhost:5255/api/sections`).then((response) =>
    setInfo(JSON.stringify(response.data))
  );

  return <p>{info}</p>;
}
