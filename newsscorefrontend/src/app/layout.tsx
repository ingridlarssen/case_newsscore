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
        <main>{children}</main>
        {children}
      </body>
    </html>
  );
}
