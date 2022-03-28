const { createProxyMiddleware } = require("http-proxy-middleware");

const context = ["/api"];

module.exports = function (app) {
  const appProxy1 = createProxyMiddleware(context, {
    target: "https://localhost:7218",
    secure: false,
  });

  const appProxy2 = createProxyMiddleware(context, {
    target: "https://localhost:44372",
    secure: false,
  });

  //app.use(appProxy1);
  app.use(appProxy2);
};
