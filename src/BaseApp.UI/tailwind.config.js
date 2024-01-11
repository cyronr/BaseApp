/** @type {import('tailwindcss').Config} */
module.exports = {
  content: ['./**/*.{razor,html}'],
  theme: {
      extend: {
          colors: {
              'navy-blue-100': '#5b80a4',
              'navy-blue-200': '#517394',
              'navy-blue-300': '#486684',
              'navy-blue-400': '#3f5973',
              'navy-blue-500': '#364d63',
              'navy-blue-600': '#34495e',
              'navy-blue-700': '#2d4052',
              'navy-blue-800': '#243342',
              'navy-blue-900': '#1b2631',

              'light-gray-100': '#f0f3f4',
              'light-gray-200': '#ecf0f1',
              'light-gray-300': '#e2e8e9',
              'light-gray-400': '#d3dcde',
              'light-gray-500': '#c4d1d4',
              'light-gray-600': '#b6c5c9',
              'light-gray-700': '#a7b9be',
              'light-gray-800': '#98aeb3',
              'light-gray-900': '#8aa2a8',

              'brigh-green-100': '#2ecc71'
          }
      },
  },
  plugins: [],
}

