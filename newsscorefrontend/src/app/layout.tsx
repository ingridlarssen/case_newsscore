import './globals.css';
import NewsscoreContainer from './newsscoreContainer';

export default function RootLayout({
  children,
}: Readonly<{
  children: React.ReactNode;
}>) {
  return (
    <html lang='en'>
      <body>
        <NewsscoreContainer />
      </body>
    </html>
  );
}
