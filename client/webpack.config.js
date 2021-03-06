const path = require('path');
const MiniCssExtractPlugin = require("mini-css-extract-plugin");
module.exports = {
    plugins: [new MiniCssExtractPlugin({ filename: "./css/[name].css" })],
    // todo: read from files with unknown names as entries, this will bottleneck at some point
    // note: always denote the js files after css or this won't work
    entry: {
        site: './js/site.tsx',
        siteStyle: "./css/site.scss",

        layout: "./js/layout.ts",
        layoutStyle: "./css/layout.scss",
        
        contentStyle: "./css/content.scss",

        images: "./img/images.ts"
    },
    output: {
        filename: 'js/[name].js',
        path: path.resolve(__dirname, '..', 'wwwroot')
    },
    devtool: 'source-map',
    mode: 'development',
    module: {
        rules: [
            {
                test: /\.(js|jsx|tsx|ts)$/,
                exclude: /node_modules/,
                use: ["babel-loader"]
            },
            {
                test: /\.(sc|c)ss$/,
                use: [MiniCssExtractPlugin.loader, 'css-loader', "sass-loader"],
                include: /css/,
            },
            { test: /\.eot(\?v=\d+\.\d+\.\d+)?$/, use: ['file-loader'] },
            {
                test: /\.(woff|woff2)$/, use: [
                    {
                        loader: 'url-loader',
                        options: {
                            limit: 5000,
                        },
                    },
                ]
            },
            {
                test: /\.ttf(\?v=\d+\.\d+\.\d+)?$/, use: [
                    {
                        loader: 'url-loader',
                        options: {
                            limit: 10000,
                            mimetype: 'application/octet-stream',
                        },
                    },
                ]
            },
            {
                test: /\.svg(\?v=\d+\.\d+\.\d+)?$/, use: [
                    {
                        loader: 'url-loader',
                        options: {
                            limit: 10000,
                            mimetype: 'image/svg+xml',
                        },
                    },
                ]
            },
            {
                test: /\.(svg|jpe?g|gif|png)$/i,
                loader: 'file-loader',
                options: {
                    name: 'img/[name].[ext]',
                },
            },
        ]
    }
};
