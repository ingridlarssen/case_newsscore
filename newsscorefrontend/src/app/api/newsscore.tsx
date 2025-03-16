export async function FetchNewsscore(request: {
  measurements: { type: string; value: number }[];
}) {
  const response = await fetch('http://localhost:5166/api/newsscore', {
    method: 'POST',
    headers: {
      'Content-Type': 'application/json',
    },
    body: JSON.stringify(request),
  });

  return response;
}
