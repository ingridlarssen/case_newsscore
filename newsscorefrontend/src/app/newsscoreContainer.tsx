'use client';

import React from 'react';
import styles from './newsscoreContainer.module.css';
import Form from 'next/form';
import { FetchNewsscore } from './api/newsscore';
import InputContainer from './inputContainer';

export default function NewsscoreContainer() {
  const [temperature, setTemperature] = React.useState('');
  const [heartRate, setHeartrate] = React.useState('');
  const [respiratoryRate, setRespiratoryRate] = React.useState('');
  const [newsscore, setNewsscore] = React.useState<number | undefined>(
    undefined
  );
  const [error, setError] = React.useState<string | undefined>(undefined);

  const getNewsScore = async () => {
    try {
      var requestBody = {
        measurements: [
          { type: 'TEMP', value: Number(temperature) },
          { type: 'HR', value: Number(heartRate) },
          { type: 'RR', value: Number(respiratoryRate) },
        ],
      };

      const response = await FetchNewsscore(requestBody);

      const responseObject = await response.json();

      if (response.ok) {
        setError(undefined);
        setNewsscore(responseObject.score);
      } else {
        setNewsscore(undefined);
        setError(responseObject.message);
      }
    } catch (e) {
      setError('Noe gikk galt');
    }
  };

  const handleReset = () => {
    setTemperature('');
    setHeartrate('');
    setRespiratoryRate('');
    setNewsscore(undefined);
    setError(undefined);
  };

  return (
    <div className={styles.newsscoreContainer}>
      <h2>NEWS score calculator</h2>

      <Form action={getNewsScore}>
        <InputContainer
          value={temperature}
          setValue={setTemperature}
          header={'Body temperature'}
          description={'Degrees Celcius'}
        />

        <InputContainer
          value={heartRate}
          setValue={setHeartrate}
          header={'Heartrate'}
          description={'Beats per minute'}
        />

        <InputContainer
          value={respiratoryRate}
          setValue={setRespiratoryRate}
          header={'Respiratory rate'}
          description={'Breaths per minute'}
        />

        <div className={styles.buttonContainer}>
          <button className={styles.submitButton} type='submit'>
            Calculate NEWS score
          </button>
          <button
            onClick={() => handleReset()}
            type='button'
            className={styles.button}
          >
            Reset form
          </button>
        </div>
      </Form>

      {newsscore && (
        <div className={styles.resultsContainer}>News score: {newsscore}</div>
      )}
      {error && <div>{error}</div>}
    </div>
  );
}
