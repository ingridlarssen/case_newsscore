import styles from './newsscoreContainer.module.css';

interface InputContainerProps {
  header: string;
  description: string;
  value: string;
  setValue: (e: string) => void;
}

export default function InputContainer({
  header,
  description,
  value,
  setValue,
}: InputContainerProps) {
  return (
    <div className={styles.inputContainer}>
      <h3>{header}</h3>
      <p>{description}</p>
      <input
        value={value}
        onChange={(e) => setValue(e.target.value)}
        className={styles.input}
      ></input>
    </div>
  );
}
