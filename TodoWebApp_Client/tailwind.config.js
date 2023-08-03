/** @type {import('tailwindcss').Config} */
module.exports = {
    content: [
        "./src/**/*.{js,jsx,ts,tsx}",
        "./node_modules/tw-elements/dist/js/**/*.js",
    ],
    darkMode: "class",
    theme: {
        screens: {
            tabletOrDesktop: "600px",
            Desktop: "1281px",
        },
        colors: {
            white: "#fff",
            black: "#09090b",

            // Color-Picker

            // End Color-Picker

            red: {
                500: "#ef4444",
                600: "#dc2626",
            },
            yellow: {
                200: "#fef08a",
                500: "#eab308",
            },
            neutral: {
                100: "#f5f5f5",
                200: "#e5e5e5",
                400: "#a3a3a3",
                500: "#737373",
                700: "#404040",
                800: "#262626",
            },
            gray: {
                100: "#f3f4f6",
                200: "#e5e7eb",
                300: "#d1d5db",
                400: "#9ca3af",
                900: "#111827",
            },
            slate: {
                50: "#f8fafc",
                300: "#cbd5e1",
            },
            lime: {
                300: "#bef264",
                500: "#84cc16",
                600: "#65a30d",
            },
            purple: {
                500: "#a855f7",
            },
            primary: "#0ea5e9",
            fade: "#f8fafc",
        },
        extend: {},
    },
    plugins: [require("tw-elements/dist/plugin.cjs")],
};
